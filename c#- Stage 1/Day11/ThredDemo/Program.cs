namespace ThreadDemo

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread video = new Thread(ShowVideo);
            Thread audio = new Thread(PlayAudio);
            video.Start();
            audio.Start();
            audio.IsBackground = true;
            Thread t = Thread.CurrentThread;
            t.Join(1000);
            Console.WriteLine("End of program");
        }

        static void ShowVideo()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("showing video");
                Thread.Sleep(10);
            }
        }

        static void PlayAudio()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Playing audio");
            }
        }
    }
}