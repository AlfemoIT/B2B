using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class MATERIAL_GRUB
    {
        public List<Tvm1t> tvm1s { get; set; }
        public List<Tvm2t> tvm2ts { get; set; }
        public List<Tvm3t> tvm3ts { get; set; }
        public List<Tvm4t> tvm4ts { get; set; }
        public List<Tvm5t> tvm5ts { get; set; }
        public List<StoffCode> stoffCodes { get; set; }
        public List<Cawnt> legColors { get; set; }
        public List<Cawnt> useCases { get; set; }
    }
}