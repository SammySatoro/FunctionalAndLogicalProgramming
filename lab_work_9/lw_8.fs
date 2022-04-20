module lw_8
open System
open System.Windows.Forms
open System.Text.RegularExpressions

let form = new Form(Text = "Array s**t", Width = 400, Height = 240)

let textBox1 = new TextBox(Multiline = false, Location = Drawing.Point(55, 50), Width = 120)
let textBox2 = new TextBox(Multiline = false, Location = Drawing.Point(210, 50), Width = 120) 
let button = new Button(Dock = DockStyle.Bottom, Text = "CALCULATE")



button.Click.AddHandler(fun _ _ ->
    let tb1String = textBox1.Text |> String.filter(fun c -> Regex.IsMatch(Convert.ToString(c), @"[0-9]"))
    let tb2String = textBox2.Text |> String.filter(fun c -> Regex.IsMatch(Convert.ToString(c), @"[0-9]"))            

    MessageBox.Show(string(
                                            match tb1String with
                                            |"" -> 0
                                            |_ -> int tb1String
                                            -
                                            match tb2String with
                                            |"" -> 0
                                            |_ -> int tb2String                                        
                                            )
        ) |> ignore 
    )
form.Controls.Add(textBox1)
form.Controls.Add(textBox2)
form.Controls.Add(button)
