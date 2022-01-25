using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace Datacar.Client.Auth
{
    public class TokenRenewer : IDisposable
    {
        public TokenRenewer(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        Timer timer;
        private readonly ILoginService loginService;

        public void Initiate()
        {
            timer = new Timer();
            timer.Interval = 1000 * 60 * 4; // 4 minutes - this timer should be smaller than the renew token
            //timer.Interval = 5000; // 5 secs to test
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("timer elapsed");
            loginService.TryRenewToken();
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}
