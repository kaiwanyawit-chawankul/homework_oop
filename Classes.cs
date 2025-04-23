public class Animal
{
    // Correct way to define a virtual method in the base class
    public virtual void Sound()
    {
        Console.WriteLine("Animal makes a sound");
    }
}

// Correctly implement the interface for the whole class
public interface IAves
{
    void Sound();
    // Interface method for flying
    void Fly();
}

// Correctly implement the interface for some methods
public interface ICanFly
{
    // Interface method for flying
    void Fly();
}

public class Bird : Animal, IAves, ICanFly
{
    // Correctly override the virtual method from Animal
    public override void Sound()
    {
        Console.WriteLine("Bird chirps");
    }

    // Implement the method from the IFly interface
    public void Fly()
    {
        Console.WriteLine("Bird is flying");
    }
}

// eagle need to new the Fly method
public class Eagle : Bird
{
    // Override the Sound method
    public override void Sound()
    {
        Console.WriteLine("Eagle screeches");
    }

    // Implement the Fly method from the ICanFly interface
    public new void Fly()
    {
        Console.WriteLine("Eagle is soaring high");
    }
}

public interface IPenguin
{
    // Interface method for swimming
    void Swim();
    // Interface method for flying
    void Fly();
}

public class Penguin : Bird, IPenguin
{
    // Override the Sound method
    public override void Sound()
    {
        Console.WriteLine("Penguin squawks");
    }

    // Implement the Fly method from the ICanFly interface
    public new void Fly()
    {
        Console.WriteLine("Penguin cannot fly");
    }

    public void Swim()
    {
        Console.WriteLine("Penguin is swimming");
    }

    public void Walk()
    {
        throw new NotImplementedException();
    }
}

public interface ICanSwim
{
    // Interface method for swimming
    void Swim();
}

public class Fish : Animal, ICanSwim
{
    // Override the Sound method
    public override void Sound()
    {
        Console.WriteLine("Fish blubs");
    }

    // Implement the Swim method from the ICanSwim interface
    public virtual void Swim()
    {
        Console.WriteLine("Fish is swimming");
    }
}

public class Shark : Fish
{
    // Override the Sound method
    public override void Sound()
    {
        Console.WriteLine("Shark growls");
    }

    // Implement the Swim method from the ICanSwim interface
    public override void Swim()
    {
        Console.WriteLine("Shark is swimming fast");
    }
}

//can not use Mammal as a base class
// because it is abstract
// and cannot be instantiated directly
public abstract class Mammal : Animal
{
    // Abstract method for mammal sound
    public abstract void Sound();
}

public class Dolphin : Mammal, ICanSwim
{
    // Override the Sound method
    public override void Sound()
    {
        Console.WriteLine("Dolphin clicks");
    }

    // Implement the Swim method from the ICanSwim interface
    public void Swim()
    {
        Console.WriteLine("Dolphin is swimming gracefully");
    }
}

public interface IBark
{
    // Interface method for barking
    void Bark();
}

// cannot use Dog as a base class
// because it is abstract
// and cannot be instantiated directly
// Dog is a subclass of Mammal
// and implements the ICanSwim and IBark interfaces
public abstract class Dog : Mammal, ICanSwim, IBark
{
    // Override the Sound method
    public override void Sound()
    {
        Bark();
    }

    // Implement the Bark method from the IBark interface
    public abstract void Bark();

    // Implement the Swim method from the ICanSwim interface
    public abstract void Swim();
}

public class ShihTzu : Dog
{
    public override void Bark()
    {
        Console.WriteLine("Shih Tzu barks");
    }

    public override void Swim()
    {
        Console.WriteLine("Shih Tzu is swimming");
    }
}

public class Insect : Animal
{
    private string sound = "Insect chirps";
    protected Insect(string sound)
    {
        this.sound = sound;
    }

    // Override the Sound method
    public override void Sound()
    {
        Console.WriteLine(sound);
    }

    public static Insect HatchBug()
    {
        return new Bug();
    }

    public static Insect HatchCaterpillar()
    {
        return new Caterpillar();
    }

    public class Bug: Insect
    {
        public Bug():base("Bug buzzes")
        {

        }
    }

    public class Butterfly: Insect
    {
        public Butterfly():base("Butterfly flutters")
        {

        }
    }

    public interface ICaterpillar
    {
        // Interface method for metamorphosis
        Insect Metamorphose();
    }

    public class Caterpillar: Insect, ICaterpillar
    {
        public Caterpillar():base("Caterpillar crawls")
        {

        }

        public Insect Metamorphose()
        {
            Console.WriteLine("Caterpillar metamorphoses into a butterfly");
            sound = "Butterfly flutters";
            this.Sound();
            return this;
        }
    }
}



