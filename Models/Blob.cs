using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Blob
    {
        public int Id { get; set; }
        public string BlobName { get; set; }
        public string Description { get; set; }
        public DateTime UploadedDate { get; set; }
        public string UploadedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public string BlobUrl { get; set; }
    }
}
