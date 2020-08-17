using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }

        public string Family { get; set; }
    }
}
