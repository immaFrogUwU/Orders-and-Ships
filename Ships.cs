class Program
    {
        static void Main()
        {
            int totalFinishedShips = 0; // số tàu đã chuyển hàng
            Queue<int> waitingShips = new Queue<int>(); // danh sách tàu đang đợi chuyển hàng
            Stack<int> parkedShips = new Stack<int>(); // danh sách tàu đang chuyển hàng trong bến
            

            Random random = new Random();

            // vòng lặp để giả lập đến và đi của tàu
            while (true)
            {
                // nếu bến trống, cho 1 tàu mới vào bến
                if (parkedShips.Count == 0)
                {
                    WriteLine("A new ship has arrived.");             //Có tàu mới đến
                    waitingShips.Enqueue(totalFinishedShips);         //Khi tàu mới đến thì thêm vào danh sách đợi đến lượt chuyển hàng
                    int totalShip = 0;                                //Tổng số tàu vào bến
                    totalShip++;   
                    
                    // biến thời gian chuyển hàng
                    int timeToTransfer = random.Next(3, 7);
                    WriteLine($"The ship is transferring cargo for {timeToTransfer} seconds.");     //Tau đang chuyển hàng trong x giây

                    // thêm tàu vào danh sách chuyển hàng trong bến
                    parkedShips.Push(waitingShips.Dequeue());

                    // gia tăng số lượng tàu đã được chuyển
                    totalFinishedShips++;
                    

                    // Tàu đã chuyển hàng xong trong y giây. Tổng số tàu đã chuyển là z, hàng đợi có w tàu 
                    WriteLine($"The ship has finished transferring cargo. Total ships has finished: {totalFinishedShips}");
                }
                else
                {
                    
                    // nếu bến có tàu đang chuyển hàng, tàu mới đến cần phải đợi
                    WriteLine("A new ship has arrived but have to wait.");
                    waitingShips.Enqueue(totalFinishedShips);

                    // hiển thị tổng số tàu đã chuyển và tàu đang đợi
                    WriteLine($"Total ships: {totalFinishedShips}");
                }

                // chờ khoảng thời gian ngẫu nhiên trước khi tàu tiếp theo đến
                int waitTime = random.Next(5, 10);
                WriteLine($"Waiting {waitTime} seconds until the next ship arrives.\n");
                Thread.Sleep(waitTime * 1000);

                // nếu tàu đang chuyển hàng đã hoàn thành, loại ra khỏi danh sách 
                if (parkedShips.Peek() == totalFinishedShips - 1)
                {
                    parkedShips.Pop();
                }
            }
        }
    }
