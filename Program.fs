open System

// Define the Records
type Coach = { Name: string; FormerPlayer: bool }
type Stats = { Wins: int; Losses: int }
type Team = { Name: string; Coach: Coach; Stats: Stats }

// Create the List of Teams
let teams = [
    { Name = "Lakers"; Coach = { Name = "Phil Jackson"; FormerPlayer = true }; Stats = { Wins = 2305; Losses = 1562 } }
    { Name = "Celtics"; Coach = { Name = "Red Auerbach"; FormerPlayer = false }; Stats = { Wins = 3550; Losses = 2545 } }
    { Name = "Warriors"; Coach = { Name = "Steve Kerr"; FormerPlayer = true }; Stats = { Wins = 2665; Losses = 3253 } }
    { Name = "Bulls"; Coach = { Name = "Phil Jackson"; FormerPlayer = true }; Stats = { Wins = 2662; Losses = 2034 } }
    { Name = "Spurs"; Coach = { Name = "Gregg Popovich"; FormerPlayer = false }; Stats = { Wins = 2355; Losses = 2745 } }
]

// Filter Successful Teams
let successfulTeams = 
    teams 
    |> List.filter (fun team -> team.Stats.Wins > team.Stats.Losses)

// Calculate Success Percentage
let calculateSuccessPercentage team =
    let wins = float team.Stats.Wins
    let losses = float team.Stats.Losses
    (wins / (wins + losses)) * 100.0

// Map Teams to Success Percentages
let successPercentages = 
    teams 
    |> List.map (fun team -> (team.Name, calculateSuccessPercentage team))

// Display Results
printfn "All Teams:"
teams |> List.iter (fun team -> 
    printfn "Team: %s, Coach: %s, Wins: %d, Losses: %d" 
        team.Name team.Coach.Name team.Stats.Wins team.Stats.Losses)

printfn "\nSuccessful Teams (Wins > Losses):"
successfulTeams |> List.iter (fun team -> 
    printfn "Team: %s, Wins: %d, Losses: %d" 
        team.Name team.Stats.Wins team.Stats.Losses)

printfn "\nSuccess Percentages:"
successPercentages |> List.iter (fun (name, percentage) -> 
    printfn "Team: %s, Success Percentage: %.2f%%" name percentage)


 
 // Define the Cuisine Discriminated Union
type Cuisine = 
    | Korean
    | Turkish

// Define the MovieType Discriminated Union
type MovieType =
    | Regular
    | IMAX
    | DBOX
    | RegularWithSnacks
    | IMAXWithSnacks
    | DBOXWithSnacks

// Define the Activity Discriminated Union
type Activity =
    | BoardGame
    | Chill
    | Movie of MovieType
    | Restaurant of Cuisine
    | LongDrive of distance: int * fuelCostPerKm: float

// Function to calculate the budget
let calculateBudget activity =
    match activity with
    | BoardGame -> 0
    | Chill -> 0
    | Movie movieType ->
        match movieType with
        | Regular -> 12
        | IMAX -> 17
        | DBOX -> 20
        | RegularWithSnacks -> 12 + 5
        | IMAXWithSnacks -> 17 + 5
        | DBOXWithSnacks -> 20 + 5
    | Restaurant cuisine ->
        match cuisine with
        | Korean -> 70
        | Turkish -> 65
    | LongDrive (distance, fuelCostPerKm) ->
        int (float distance * fuelCostPerKm)

// Example activities and results
let activity1 = BoardGame
let activity2 = Chill
let activity3 = Movie RegularWithSnacks
let activity4 = Restaurant Korean
let activity5 = LongDrive (50, 0.15)

// Calculate and print budgets for activities
printfn "Budget for BoardGame: %d CAD" (calculateBudget activity1)
printfn "Budget for Chill: %d CAD" (calculateBudget activity2)
printfn "Budget for Movie (RegularWithSnacks): %d CAD" (calculateBudget activity3)
printfn "Budget for Restaurant (Korean): %d CAD" (calculateBudget activity4)
printfn "Budget for LongDrive (50 km, 0.15 CAD/km): %d CAD" (calculateBudget activity5)
