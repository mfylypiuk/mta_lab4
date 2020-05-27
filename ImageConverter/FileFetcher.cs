/*
    NOTE: This class is only a part of a project
*/
/*
    Author : Noorsil Karedia
    Index  : Comments with /**/  /*
             contains general information for class, variables, and methods
             Comments with ( // ) 
             contains information for that specific statement on the line
                
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Collections;

/*
    This class is used in a project called Image Converter which converts 
    images to various image formats
*/
namespace ImageConverter   
{
    
    /*
        File Fetcher class allows user to open file or folder dialog to select multiple
        image files or folder containing image files.
    */
    class FileFetcher
    {
        private OpenFileDialog open; 
        private FolderBrowserDialog folder;
        private string absolutePath;        // absolutePath contains path to store all images after converted 
        /*
            NOTE: string[] filename, extension, FileNameWithPath are parallel arrays in nature
        */
        private string[] filename;          // stores file names that are selected by user
        private string[] extension;         // stores file extension for all files stored in filename array. 
        private string[] FileNameWithPath;  // stores full path of all files
        
                                           

        /*
            Constructor constructs all objects required and sets all strings to null
        */
        public FileFetcher()
        {
            open = new OpenFileDialog();
            folder = new FolderBrowserDialog();
            filename = null;
            absolutePath = null;
            extension = null;
            FileNameWithPath = null;
        }

        
        /*
            fetch method process opening and close file or folder dialog and extracts all
            components.
        */
        public string Fetch(string type)
        {
            string pth = null;                          // Temporary reference to store a single file path
            if (type.ToLower() == "files")              // If user select to open file dialog
            {
                ArrayList FileName = new ArrayList();   // Temporary storing of filenames
                ArrayList Ext = new ArrayList();        // Temporary storing of extension
                
                // sets extension filter for file dialog 
                
                open.FilterIndex = 1;
                open.Multiselect = true;
                open.Title = "Select Multiple Files";
                
                /*
                    if user selects atleast one file 
                */
                if (open.ShowDialog() == DialogResult.OK)
                {
                    FileNameWithPath = open.FileNames;                            // Store all files in array
                    absolutePath = Path.GetDirectoryName(FileNameWithPath[0]);    // store absolute path for all files
                    pth = Path.GetDirectoryName(FileNameWithPath[0]);             // Temporary store absolute path
                    ExtractImageFiles(FileNameWithPath);                          // <-- Member function -->
                }

            }
            else if (type.ToLower() == "folder")  /*  if user selects folder dialog  */
            {
                folder.Description = "Select a Folder in which Multiple Image Files Resides";
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    pth = folder.SelectedPath;                                   // Temporary store absolute path
                    this.absolutePath = folder.SelectedPath;                     // Store Absolute path for selected folder
                    string[] f = Directory.GetFiles(folder.SelectedPath);        // Temporary Store all files from folder
                    ExtractImageFiles(f);                                        // <-- Member function -->
                }
            }
            return pth; // return absolute path
        }


        /*
            Extract Image files if user has selected folder from folder dialog
            and stores in an array
        */
        private void ExtractImageFiles(string[] files)
        {
            ArrayList imgFiles = new ArrayList();                   // Temporary stores image files
            ArrayList FileName = new ArrayList();                   // Temporary stores filenames
            ArrayList Ext = new ArrayList();                        // Temporary stores extension of files
            for (int i = 0; i < files.Length; i++)
            {
                /*
                    Check if filepath ends with following extension then add it in list
                */
                if (files[i].EndsWith(".png") || files[i].EndsWith(".jpg") || files[i].EndsWith(".bmp") ||
                    files[i].EndsWith(".gif") || files[i].EndsWith(".wmf") || files[i].EndsWith(".tif") ||
                    files[i].EndsWith(".ico") || files[i].EndsWith(".emf") || files[i].EndsWith(".tiff"))
                {
                    imgFiles.Add(files[i]);
                    ExtractFilenameAndExtension(files[i], FileName, Ext);    // <-- Member function -->
                }
            }
            
            /*
                Store filename, extension,and path to their respective private member variables
            */
            this.FileNameWithPath = (string[])imgFiles.ToArray(typeof(string));
            this.filename = (string[])FileName.ToArray(typeof(string));
            this.extension = (string[])Ext.ToArray(typeof(string));
        }


        /*
            This method extracts filename and extension from a complete path
            and adds the values to list (2nd and 3rd parameter)
        */
        private void ExtractFilenameAndExtension(string filePath, ArrayList AddfileName, ArrayList Addext)
        {
            string[] splitPath = filePath.Split('\\');                                   // Split directories and files
            string[] splitNameAndExtension = splitPath[splitPath.Length - 1].Split('.'); // Split filename and extension 
                                                                                         // from last index of splitPath array
            string concatName = null;                                                    // Concats filename with dot(.) 
            Addext.Add("."+splitNameAndExtension[splitNameAndExtension.Length - 1]);     // add extension to the list 
            
            /*
                Concats a filename with dot(.) which was split above
                eg : image.bitmap.jpg --> Concats image and bitmap together
            */
            for (int j = 0; j < splitNameAndExtension.Length - 1; j++)
            {
                concatName += splitNameAndExtension[j];
                if (j < splitNameAndExtension.Length - 2)
                    concatName += ".";
            }
            AddfileName.Add(concatName);                                                 // Adds filename to the list
        }


        /*
            returns all file WITHOUT respected path
        */
        public string[] GetFileNames()
        {
            return this.filename;
        }

        /*
            returns all extension of files
        */
        public string[] GetExtension()
        {
            return this.extension;
        }


        /*
            return array of files with respected path
        */
        public string[] GetFileWithPath()
        {
            return this.FileNameWithPath;
        }


        /*
            return true if there is no file stored in the current object
        */
        public bool IsEmpty()
        {
            bool ret = false;
            if (filename == null && extension == null && FileNameWithPath == null && absolutePath == null)
                ret = true;
            return ret;
        }
    }
}
