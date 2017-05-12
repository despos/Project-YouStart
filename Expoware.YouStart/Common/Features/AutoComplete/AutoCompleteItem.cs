using System;

namespace Expoware.YouStart.Common.Features.AutoComplete
{
    public class AutoCompleteItem
    {
        // Display text for the drop-down list (contains HTML styles)
        public String label { get; set; }

        // Unique ID of the returned item
        public String id { get; set; }

        // Value to copy in the textbox
        public String value { get; set; }
    }
}