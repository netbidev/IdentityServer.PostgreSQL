﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceFileServer.Providers
{
    public class SecuredFileProvider : ISecuredFileProvider
    {
        private List<string> _fileIds;

        public SecuredFileProvider()
        {
            // create the demo data, this could be data from a database or file provider...
            _fileIds = new List<string> { "securefile.txt", "securefileadmin.txt", "securefiletwo.txt" };
        }

        public bool FileIdExists(string fileId)
        {
            if(_fileIds.Contains(fileId.ToLower()))
            {
                return true;
            }

            return false;
        }

        public List<string> GetFilesForUser(bool isSecuredFilesAdmin)
        {
            List<string> files = new List<string>();
            files.Add("SecureFile.txt");
            files.Add("SecureFileTwo.txt");

            // Use the claims to check if the logged in use has admin rights.
            if (isSecuredFilesAdmin)
            {
                files.Add("SecureFileAdmin.txt");
            }

            return files;
        }

        public bool HasUserClaimToAccessFile(string fileId, bool isSecuredFilesAdmin)
        {
            if ("SecureFileAdmin.txt" == fileId && !isSecuredFilesAdmin)
            {
                return false;
            }

            return true;


        }
    }
}