using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Entity
{
    public class Image
    {        
        public int ImageId { get; set; }

        public string ImageName { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
