using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public class ElevatorSystem
    {
        private List<Elevator> elevators =new();
        private int SelectedElevatorId {  get; set; }   

        public ElevatorSystem(int elevatorCount)
        {
           
            for (int i = 1; i <= elevatorCount; i++)
            {
                elevators.Add(new Elevator(i)); 
            }
        }

        public void RequestElevator(int fromFloor, int toFloor)
        {
            var request = new Request(fromFloor, toFloor);

            var selectedElevator = elevators
                .Where(e => e.IsIdle 
                            || (e.Direction == Direction.Up && fromFloor >= e.CurrentFloor)
                            || (e.Direction == Direction.Down && fromFloor <= e.CurrentFloor))
                .OrderBy(e => Math.Abs(e.CurrentFloor - fromFloor))
                .FirstOrDefault();

            if (selectedElevator == null)
            {
                selectedElevator=elevators.OrderBy(e => e.Requests.Count).First();
            }

            SelectedElevatorId= selectedElevator.Id;    
            selectedElevator.AddRequest(request);  
            

            Console.WriteLine("Request from " + fromFloor + " to " + toFloor + " assigned to Elevator " + selectedElevator.Id);

        }

        public void StartMoving()
        {
            var elToStart=elevators.FirstOrDefault(x=>x.Id== SelectedElevatorId); 
            elToStart?.StartMoving();
        }

        public void DisplayElavatorsCurrentStatus()
        {
            foreach (var elevator in elevators)
            {
                elevator.PrintDetails();
            }
        }
    }
}
