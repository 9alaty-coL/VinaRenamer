using MyRuleContract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaRenamer
{
    public class RuleParserFactory
    {
        public MyRule parse(BindingList<MyRule> rules ,string savedString)
        {
            string MW = savedString.Substring(0, savedString.IndexOf(" "));
            foreach(MyRule r in rules)
            {
                if (r.getMagicWord() == MW)
                {
                    return r.parseRule(savedString);
                }
            }
            return null;
        }
    }
}
