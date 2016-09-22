using System.Collections.Generic;

namespace ThaiApiTesting.Models
{
    public class Response
    {
        public int current_item { get; set; }

        public string query { get; set; }

        public string radius { get; set; }

        public List<Doc> docs { get; set; }

        public string next_parameter { get; set; }

        public string prev_parameter { get; set; }

        public string parameter_template { get; set; }

        public int item_found { get; set; }

        public int item_per_page { get; set; }

        public string lng { get; set; }

        public string lat { get; set; }

        public string sort_strategy { get; set; }
    }
}
