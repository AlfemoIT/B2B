using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class MATERIAL_GRUB
    {
        public List<TVM2T> tvm2ts { get; set; }
        public List<TVM3T> tvm3ts { get; set; }
        public List<TVM4T> tvm4ts { get; set; }
    }
}