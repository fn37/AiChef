using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiChef.Shared
{
    public class Idea
    {
        //id(open AI), title, description
        public int index { get; set; }  //how ideas presented here  - open AI will do this
        public string? title { get; set; }  
        public string? description { get; set; }
    }
}
