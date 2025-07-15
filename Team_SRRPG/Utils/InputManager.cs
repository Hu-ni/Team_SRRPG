using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_SRRPG.Utils
{
    public class InputManager : Singleton<InputManager>
    {
        private readonly SemaphoreSlim _inputLock = new SemaphoreSlim( 1, 1 );
        private bool isSelectedOptions = false;

        public string ReadLine()
        {
            if (isSelectedOptions) return ERROR_OPTIONS_INPUT.ToString();

            string? input = Console.ReadLine();
            if (input == null)
                return string.Empty;
            return input;
        }

        public int ReadLineInt()
        {
            if(!isSelectedOptions) return ERROR_OPTIONS_INPUT;
            int input;
            ViewHelper.PrintInput();
            if (int.TryParse(ReadLine(), out input))
                return input;
            return ERROR_INPUT_FORMATING;
        }

        public int ReadLineIntInRange(int min, int max)
        {
            if(isSelectedOptions) return ERROR_OPTIONS_INPUT;
            
            int value;
            while (true)
            {
                ViewHelper.PrintInput();
                value = ReadLineInt();
                if (value >= min && value <= max)
                    return value;

                ViewHelper.PrintInvalidInput();
            }
        }

        public async Task<int> SelectOptionAsync(List<string> options)
        {
            isSelectedOptions = true;
            int selectedIdx = 0;    // 현재 선택된 인덱스
            ConsoleKey key;
            do
            {
                ViewHelper.RenderOptions(options, selectedIdx);
                key = await ReadKeyAsync();

                int delta = 0;
                if (key == ConsoleKey.UpArrow) delta = -1;
                else if (key == ConsoleKey.DownArrow) delta = 1;

                selectedIdx = (selectedIdx + delta + options.Count) % options.Count;
            }
            while (key != ConsoleKey.Z);

            isSelectedOptions = false;
            return selectedIdx;
        }

        private async Task<ConsoleKey> ReadKeyAsync()
        {
            await _inputLock.WaitAsync();
            try
            {
                return await Task.Run(() => Console.ReadKey(true).Key);
            }
            finally
            {
                _inputLock.Release();
            }
        }

    }
}
