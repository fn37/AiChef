﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiChef.Shared
{
    public class RecipeImage
    {
        //open ai 

        public int created {  get; set; }   
        public ImageData[] data { get; set; }
    }

    public class ImageData
    {
        public string url { get; set; }
    }
}