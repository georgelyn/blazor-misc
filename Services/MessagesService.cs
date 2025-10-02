namespace Misc.Services
{
    public interface IMessagesService
    {
        Task DisplayMessageAsync(string message, bool isError = false, int durationInSeconds = 3);
        event Action<string?, bool?>? OnMessageChanged;
    }

    public class MessagesService : IMessagesService
    {
        private CancellationTokenSource? _cancellationToken;
        public event Action<string?, bool?>? OnMessageChanged;

        public MessagesService() { }

        public async Task DisplayMessageAsync(string message, bool isError = false, int durationInSeconds = 3)
        {
            _cancellationToken?.Cancel();
            _cancellationToken = new CancellationTokenSource();

            OnMessageChanged?.Invoke(message, isError);

            try
            {
                await Task.Delay(TimeSpan.FromSeconds(durationInSeconds), _cancellationToken.Token);
                OnMessageChanged?.Invoke(null, isError);
            }
            catch (Exception) { }
        }
    }
}