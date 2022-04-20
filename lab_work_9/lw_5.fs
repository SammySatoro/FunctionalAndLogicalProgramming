module lw_5
open System
open System.Windows.Forms

let form = new Form(Text = "Child form" ,Width = 480, Height = 240)

let months = 
                      [(["December"; "January"; "February"], "Winter");
                      (["March"; "April"; "May"], "Spring");
                      (["June"; "July"; "August"], "Summer");
                      (["September"; "October"; "November"], "Fall")]
    
let id = [0;1;2;3]
let jd = [0;1;2]

let buttons = 
        id |> List.map (fun i -> jd |> List.map (fun j -> new Button(Text = $"{ (fst months.[i]).[j]}", Location = Drawing.Point(i  * 120 + 15, j * 60 + 15), Name = $"{snd months.[i]}"))) |> List.collect (fun i -> i)    

for i = 0 to 11 do
        buttons.[i].Click.Add(fun e -> MessageBox.Show($"{buttons.[i].Name}") |> ignore)
        form.Controls.Add(buttons.[i])
 
do Application.Run(form)
