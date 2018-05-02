Braintwo bwKernel = new Braintwo();
            Braintwo bwHour = new Braintwo();

            string FileKernel = File.ReadAllText("os/kernel.btwo");
            string HourSystem = File.ReadAllText("os/hour.btwo");


            bwKernel.Interpreter("$0x", FileKernel);

            void KernelInfo()
            {
                Console.Clear();
                Console.WriteLine(bwKernel.Output);
                Console.WriteLine($"{bwHour.currentMemory}:{bwHour.Memory[0]}{bwHour.Memory[1]} PM");
            }

            bwHour.Memory[0] = 4;
            bwHour.Memory[1] = 8;
            bwHour.pointerMemory = 1;
            bwHour.currentMemory = 12;

            KernelInfo();

            while (true)
            {
                #region HourSystem
                    if (bwHour.Memory[0] >= 6 && bwHour.Memory[1] >= 1)
                    {
                        if (bwHour.currentMemory != 24)
                        {
                            bwHour.currentMemory = bwHour.currentMemory += 1;
                        }
                        else
                        {
                            bwHour.currentMemory = 0;
                        }
                    }
                    if(bwHour.Memory[1] >= 10)
                    {
                        bwHour.pointerMemory = 0;
                        bwHour.Memory[1] = 0;
                        bwHour.Memory[0] = bwHour.Memory[0] += 1;
                        bwHour.pointerMemory = 1;
                    }
                    Thread.Sleep(TimeSpan.FromMinutes(1));
                    bwHour.Interpreter("$1x", null,HourSystem);
                    KernelInfo();
                #endregion
            }
