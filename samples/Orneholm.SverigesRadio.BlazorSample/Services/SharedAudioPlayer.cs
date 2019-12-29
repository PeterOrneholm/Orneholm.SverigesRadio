using System;
using System.Threading.Tasks;

namespace Orneholm.SverigesRadio.BlazorSample.Services
{
    public class SharedAudioPlayer
    {
        public async Task PlayAudio(string audioUrl, string audioName)
        {
            if (Play != null)
            {
                await Play.Invoke(audioUrl, audioName);
            }
        }

        public event Func<string, string, Task> Play;
    }
}
