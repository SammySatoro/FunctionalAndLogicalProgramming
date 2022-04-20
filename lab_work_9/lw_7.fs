module lw_7
open System
open System.Windows.Forms


let form = new Form(Text = "Check-Check", Width = 300, Height = 250)

let checkBoxes = (new CheckBox(Location = Drawing.Point(70, 50)), 
                            new CheckBox(Location = Drawing.Point(200, 50)))
let button = new Button(Text = "CHECK", Location = Drawing.Point(105, 100))

button.Click.Add(fun e -> MessageBox.Show($" First is {(fst checkBoxes).CheckState} and Second is {(snd checkBoxes).CheckState}")  |> ignore)

form.Controls.Add(button)
form.Controls.Add(fst checkBoxes)
form.Controls.Add(snd checkBoxes)
