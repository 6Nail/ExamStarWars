﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSwapi
{
    class RootObject
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<Person> results { get; set; }
    }
}
