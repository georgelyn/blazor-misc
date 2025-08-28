using Microsoft.AspNetCore.Components;

namespace Misc.Shared.Models
{
    public class Button
    {
        public int Order { get; set; }
        public string Text { get; set; } = string.Empty;
        public EventCallback Event { get; set; }

        public Button(int order, string text, EventCallback @event)
        {
            Order = order;
            Text = text;
            Event = @event;
        }
    }
}