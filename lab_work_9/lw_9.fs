module lw_9
open System
open System.Windows.Forms

let form = new Form(Text = "List s**t", Width = 325, Height = 200)

let textBox1 = new TextBox(Multiline = false, Location = Drawing.Point(80, 50), Width = 180)
let textBox2 = new TextBox(Text = "2",  Multiline = false, Location = Drawing.Point(50, 50), Width = 25)

let button = new Button(Dock = DockStyle.Bottom, Text = "DELETE")

button.Click.AddHandler(fun _ _ ->
    if textBox1.Text <> "" then
        let str = textBox1.Text.Trim()        
        let items = str.Split(' ')
        if items.Length >= (int)textBox2.Text then
            let listOfItems = List.ofArray items |> List.map (fun item -> Convert.ToInt32(item)) |> List.skip (int textBox2.Text)
            textBox1.Text <- listOfItems |> List.map string |> String.concat " "
        else
            MessageBox.Show("Not enough items in the array" ) |> ignore
    else
        MessageBox.Show("Write something" ) |> ignore
    )

form.Controls.Add(textBox1)
form.Controls.Add(textBox2)
form.Controls.Add(button)
