using System;

namespace JournalApp
{
    public class JournalEntry
    {
        public DateTime Date { get; private set; }
        public string Prompt { get; private set; }
        public string Response { get; private set; }

        public JournalEntry(string prompt, string response)
        {
            Date = DateTime.Now;
            Prompt = prompt;
            Response = response;
        }

        public override string ToString()
        {
            // Format the journal entry as a string
            // This can be customized as needed
            return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
        }
    }
}