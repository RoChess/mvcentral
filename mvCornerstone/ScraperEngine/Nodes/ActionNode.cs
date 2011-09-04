﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace mvCornerstone.ScraperEngine.Nodes {
    [ScraperNode("action")]
    public class ActionNode: ScraperNode {


        public ActionNode(XmlNode xmlNode, InternalScriptSettings settings)
            : base(xmlNode, settings) {
        }

        public override void Execute(Dictionary<string, string> variables) {
            executeChildren(variables);
        }


    }
}
