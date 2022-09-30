using System.Windows.Forms;
using static System.Console;
using System.Timers;

namespace Tamagochi;

public class Toy
{
    private static System.Timers.Timer timer;
    public string Name { get; set; }
    public int DeadCounter { get; set; }

    public Toy()
    {
        this.DeadCounter = 0;
        Write("Привет! Придумай имя для своего питомца: ");
        this.Name = ReadLine();
        MessageBox.Show($"Меня зовут {this.Name}! Давай дружить!", this.Name);
    }

    public void wannaEat(object source, System.Timers.ElapsedEventArgs e)
    {
        var answer = MessageBox.Show("Покорми меня!", this.Name, MessageBoxButtons.YesNo);
        if (answer == DialogResult.Yes)
        {
            MessageBox.Show("Спасибо, очень вкусно :)", this.Name);
        } else if (answer == DialogResult.No)
        {
            MessageBox.Show("Я так и остался голодным ;(", this.Name);
            this.DeadCounter++;
            if (this.DeadCounter == 3)
            {
                this.wannaHeal();
            }
        }
    }
    
    public void wannaWalk(Object source, System.Timers.ElapsedEventArgs e)
    {
        var answer = MessageBox.Show("Погуляй со мной!", this.Name, MessageBoxButtons.YesNo);
        if (answer == DialogResult.Yes)
        {
            MessageBox.Show("Спасибо, нагулялся :)", this.Name);
        } else if (answer == DialogResult.No)
        {
            MessageBox.Show("Мои друзья опять гуляли без меня ;(", this.Name);
            this.DeadCounter++;
            if (this.DeadCounter == 3)
            {
                this.wannaHeal();
            }
        }
    }
    
    public void wannaHeal()
    {
        var answer = MessageBox.Show("Я болен, полечи меня!", this.Name, MessageBoxButtons.YesNo);
        if (answer == DialogResult.Yes)
        {
            MessageBox.Show("Спасибо, я здоров :)", this.Name);
            this.DeadCounter = 0;
        } else if (answer == DialogResult.No)
        {
            MessageBox.Show($"{this.Name} найден мёртвым в ванной....игра окончена, тупой пиздюк", this.Name);
            Environment.Exit(0);
        }
    }
    
    public void setTimer(int interval)
    {
        timer = new System.Timers.Timer();
        timer.Interval = interval;
        timer = new System.Timers.Timer(interval);
        timer.Elapsed += wannaEat;
        timer.Elapsed += wannaWalk;
        timer.AutoReset = true;
        timer.Enabled = true;
        ReadLine();
    }
}