namespace Gmail.Contracts.Pages
{
    interface ISendPage
    {
        void NavigateToSentBox();
        void SelectLetters(int count);
        void PrintSubjectToLog(int count);
    }
}