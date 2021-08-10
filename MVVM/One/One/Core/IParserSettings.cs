using System;
using System.Collections.Generic;
using System.Text;

namespace One.Core
{
    interface IParserSettings
    {
        string ModelsUrl { get; set; }
        string ComplectationUrl { get; set; }
        string SparesUrl { get; set; }
        string SparesGroupUrl { get; set; }
        string ChoosePageUrl { get; set; }
    }
}
