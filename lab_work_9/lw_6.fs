module lw_6
open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup

let mwXaml = """
<Window 
xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
 xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
 xmlns:d='http://schemas.microsoft.com/expression/blend/2008' xmlns:mc='http://schemas.openxmlformats.org/markup-compatibility/2006' mc:Ignorable='d'
 Title='What season?' Height='400' Width='400'>
    <Grid Height='400' VerticalAlignment='Center'>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width='3*' />
            <ColumnDefinition Width='0*'/>
            <ColumnDefinition Width='0*'/>
            <ColumnDefinition Width='41*'/>
            <ColumnDefinition Width='0' />
            <ColumnDefinition Width='0'/>
            <ColumnDefinition Width='211'/>
        </Grid.ColumnDefinitions>
        <GroupBox Header='Seasons&#xD;&#xA;' Height='400' HorizontalAlignment='Left' x:Name='groupBox2' VerticalAlignment='Top' Width='400' Grid.ColumnSpan='7'>
        <Button Content='Quit' Height='23' HorizontalAlignment='Left' Margin='145,300,-2,0' x:Name='exit' VerticalAlignment='Top' Width='90' /> 
        </GroupBox>
            <Button Content='December' Height='23' HorizontalAlignment='Left' Margin='90,180,0,0' x:Name='december' VerticalAlignment='Top' Width='70'  Grid.Column='3' FontSize='14'/>
            <Button Content='January' Height='23' HorizontalAlignment='Left' Margin='0,30,0,0' x:Name='january' VerticalAlignment='Top' Width='70' Grid.Column='3' FontSize='14' />
            <Button Content='February' Height='23' HorizontalAlignment='Left' Margin='0,60,0,0' x:Name='february' VerticalAlignment='Top' Width='70' Grid.Column='3' FontSize='14'/>
            <Button Content='March' Height='23' HorizontalAlignment='Left' Margin='0,90,0,0' x:Name='march' VerticalAlignment='Top' Width='70' Grid.Column='3' FontSize='14'/>
            <Button Content='April' Height='23' HorizontalAlignment='Left' Margin='0,120,0,0' x:Name='april' VerticalAlignment='Top' Width='70' Grid.Column='3' FontSize='14'/>
            <Button Content='May' Height='23' HorizontalAlignment='Left' Margin='0,150,0,0' x:Name='may' VerticalAlignment='Top' Width='70'  Grid.Column='3' FontSize='14'/>
            <Button Content='June' Height='23' HorizontalAlignment='Left' Margin='0,180,0,0' x:Name='june' VerticalAlignment='Top' Width='70'  Grid.Column='3' FontSize='14'/>
            <Button Content='Jule' Height='23' HorizontalAlignment='Left' Margin='90,30,0,0' x:Name='july' VerticalAlignment='Top' Width='70'  Grid.Column='3' FontSize='14'/>
            <Button Content='August' Height='23' HorizontalAlignment='Left' Margin='90,60,0,0' x:Name='august' VerticalAlignment='Top' Width='70'  Grid.Column='3' FontSize='14'/>
            <Button Content='September' Height='23' HorizontalAlignment='Left' Margin='90,90,0,0' x:Name='september' VerticalAlignment='Top' Width='70'  Grid.Column='3' FontSize='14'/>
            <Button Content='October' Height='23' HorizontalAlignment='Left' Margin='90,120,0,0' x:Name='october' VerticalAlignment='Top' Width='70'  Grid.Column='3' FontSize='14'/>
            <Button Content='November' Height='23' HorizontalAlignment='Left' Margin='90,150,0,0' x:Name='november' VerticalAlignment='Top' Width='70'  Grid.Column='3' FontSize='14'/>        
    </Grid>
</Window>
"""

let getWindow(mwXaml) =
    let xamlObj=XamlReader.Parse(mwXaml)
    xamlObj :?> Window

let win = getWindow(mwXaml)

let january = win.FindName("january") :?> Button
let february = win.FindName("february") :?> Button
let march = win.FindName("march") :?> Button
let april = win.FindName("april") :?> Button
let may = win.FindName("may") :?> Button
let june = win.FindName("june") :?> Button
let july = win.FindName("july") :?> Button
let august = win.FindName("august") :?> Button
let september = win.FindName("september") :?> Button
let october = win.FindName("october") :?> Button
let november = win.FindName("november") :?> Button
let december = win.FindName("december") :?> Button
let exit = win.FindName("exit") :?> Button

let winter _ = MessageBox.Show("Winter", "Season: ") |> ignore  
let spring _ = MessageBox.Show("Spring", "Season: ") |> ignore  
let summer _ = MessageBox.Show("Summer", "Season: ") |> ignore
let autumn _ = MessageBox.Show("Fall", "Season: ") |> ignore 

let _ = january.Click.Add(winter)
let _ = february.Click.Add(winter)
let _ = december.Click.Add(winter)
let _ = march.Click.Add(spring)
let _ = april.Click.Add(spring)
let _ = may.Click.Add(spring)
let _ = june.Click.Add(summer)
let _ = july.Click.Add(summer)
let _ = august.Click.Add(summer)
let _ = september.Click.Add(autumn)
let _ = october.Click.Add(autumn)
let _ = november.Click.Add(autumn)

exit.Click.AddHandler(fun _ _ -> win.Close())

let openWin =   
    win.ShowDialog()    

[<STAThread>]    
ignore <| (new Application()).Run(win)
