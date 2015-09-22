using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using iTextSharp.text.pdf;
using System.util.collections;
using iTextSharp.text;
using System.Net.Mail;

namespace PDFCombinerApplication
{
    public partial class Form1 : Form
    {
        private List<string> CoverLetterList = new List<string>();
        private string ResumeStringLocation;
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
            //Sets initial state
            PDFCombineAbleState();
        }

        #region Button Event Handlers
        private void CoverLetterButton_Click(object sender, EventArgs e)
        {
            //Settings for the open file dialog
            openFileDialog.Multiselect = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|All files(*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string outputMessage = "Files Selected - \n";
                    foreach ( string filename in openFileDialog.FileNames)
                    {
                        //Adds to the CoverLetter list
                        CoverLetterList.Add(filename);
                        //Gets the real file name
                        string realFileName = System.IO.Path.GetFileName(filename);
                        //Adds to the output message
                        outputMessage += CoverLetterList.Count + ". " + realFileName + "\n";
                    }
                    MessageBox.Show(outputMessage + " added!");
                }
                catch
                {
                    MessageBox.Show("Please Select a file!");
                }

                //Sets new state
                PDFCombineAbleState();
            }
        }

        private void ResumeButton_Click(object sender, EventArgs e)
        {
            //Settings for the open file dialog
            openFileDialog.Multiselect = false;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|All files(*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ResumeStringLocation = openFileDialog.FileName;
                    string fileName = System.IO.Path.GetFileName(ResumeStringLocation);
                    MessageBox.Show(fileName + " added!");
                }
                catch
                {
                    MessageBox.Show("Please Select a file!");
                }
                
                //Sets new state
                PDFCombineAbleState();
            }
        }

        private void CombineButton_Click(object sender, EventArgs e)
        {
            foreach (string coverletterLocation in CoverLetterList)
            {
                string fileLocation = Path.GetDirectoryName(coverletterLocation);
                string filename = Path.GetFileNameWithoutExtension(coverletterLocation);
                //CR-> Coverletter and Resume
                string[] CR = new string[] {  coverletterLocation, ResumeStringLocation };
                //Creates the name used for coverletter + resume
                string SaveLocation =  Path.Combine(fileLocation,filename + " + Resume.pdf ");
                if (!MergePDFs(CR, SaveLocation))
                {
                    MessageBox.Show("OHOHOH!");
                }
            }
            MessageBox.Show("completed!!!!");
            //Resets buttons
            ResumeStringLocation = null;
            CoverLetterList = new List<string>();
            PDFCombineAbleState();
        }
        #endregion

        private void PDFCombineAbleState()
        {
            if (ResumeStringLocation != null)
            {
                CoverLetterButton.Enabled = true;
            }

            if (!CheckIfListEmpty(CoverLetterList))
            {
                CombineButton.Enabled = true;
            }

            //If no resume or coverletters
            if (ResumeStringLocation == null & CheckIfListEmpty(CoverLetterList))
            {
                CombineButton.Enabled = false;
                CoverLetterButton.Enabled = false;
            }
        }

        #region Helper Methods

        private bool CheckIfListEmpty(List <string> listString)
        {
            return (listString.Count == 0);
        }

        //Code found on net
        /// <summary>
        /// Gets the 2 file names in the array and adds in that specific order
        /// </summary>
        /// <param name="fileNames"></param>
        /// <param name="targetPdfName"></param>
        /// <returns></returns>
        private static bool MergePDFs(string[] fileNames, string targetPdfName)
        {
            bool merged = true;
            using (FileStream stream = new FileStream(targetPdfName, FileMode.Create))
            {
                Document document = new Document();
                PdfCopy pdf = new PdfCopy(document, stream);
                PdfReader reader = null;
                try
                {
                    document.Open();
                    foreach (string file in fileNames)
                    {
                        reader = new PdfReader(file);
                        pdf.AddDocument(reader);
                        reader.Close();
                    }
                }
                catch (Exception)
                {
                    merged = false;
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
                finally
                {
                    if (document != null)
                    {
                        document.Close();
                    }
                }
            }
            return merged;
        }

        #endregion


    }
}
