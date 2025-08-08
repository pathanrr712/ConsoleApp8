
using ConsoleApp8;

ElevatorSystem system = new ElevatorSystem(3);
while (true)
{
    Console.WriteLine("Menu: \n\t 1: Request for Elevator \n\t 2: Start Moving \n\t 3: Display current status of Elevators  \n\t 4: Exit from program");
    Console.WriteLine("Enter your choice:");
    var ch = Convert.ToInt16(Console.ReadLine());

    switch (ch)
    {
        case 1:
            Console.Write("Enter from floor (0-15): ");
            int from = Convert.ToInt16(Console.ReadLine());

            Console.Write("Enter to floor (0-15): ");
            int to = Convert.ToInt16(Console.ReadLine());

            if (from != to)
                system.RequestElevator(from, to);
            else
                Console.WriteLine("From and To floor cannot be same.");
            break;

        case 2:
            system.StartMoving();
            break;

        case 3:
            system.DisplayElavatorsCurrentStatus();
            break;

        case 4:
            return; 

        default:
            Console.WriteLine("Invalid choice. Please enter a number from 1 to 4.");
            break;
    }
}
