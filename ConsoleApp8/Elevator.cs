using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public enum Direction { Up, Down, Idle }
    public class Elevator
    {

        public int Id { get; }
        public int CurrentFloor { get;  set; } = 0;
        public Direction Direction { get;  set; } = Direction.Idle;
        public Queue<Request> Requests { get; } = new();

        public bool IsIdle => Requests.Count == 0;

        public Elevator(int id)
        {
            Id = id;
        }

        public void AddRequest(Request req)
        {
            Requests.Enqueue(req);
            UpdateDirection();
        }

        public void StartMoving()
        {
            if (Requests.Count == 0)
            {
                Direction = Direction.Idle;
                return;
            }

            var currentReq = Requests.Peek();

           
                CurrentFloor = currentReq.ToFloor;
                Requests.Dequeue();
                Console.WriteLine("Elevator "+Id+" completed request it is currently at floor "+CurrentFloor);
            
        }

        private void UpdateDirection()
        {
            if (Requests.Count == 0)
            {
                Direction = Direction.Idle;
                return;
            }

            var req = Requests.Peek();
            if (CurrentFloor < req.FromFloor)
            {
                Direction = Direction.Up;
            }
            else if (CurrentFloor > req.FromFloor)
            {
                Direction = Direction.Down;
            }
            else if (req.ToFloor > CurrentFloor)
            {
                Direction = Direction.Up;
            }
            else if (req.ToFloor < CurrentFloor)
            {
                Direction = Direction.Down;
            }
            else
            {
                Direction = Direction.Idle;
            }

        }

        public  void  PrintDetails()
        {
            Console.WriteLine("Elevator: " + Id + "\t Current Floor:" + CurrentFloor + "\t Current Direction " + Direction);
             
        }
    }
}
