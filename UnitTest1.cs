namespace homework_oop;

public class UnitTest1
{
    readonly StringWriter stringWriter = new System.IO.StringWriter();
    public UnitTest1()
    {
        Console.SetOut(stringWriter);
    }

    [Fact]
    public void TestBird()
    {
        // Arrange: Create an instance of the Bird class
        Bird myBird = new Bird();

        // Act: Call the Fly method
        myBird.Fly();      // Output: Bird is flying

        // Assert: Verify that the correct message was printed to the console
        var output = stringWriter.ToString().Trim();
        Assert.Equal("Bird is flying", output);
    }

    [Fact]
    public void TestEagle()
    {
        // Given
        Eagle eagle = new Eagle();

        // When
        eagle.Sound(); // Output: Eagle screeches
        eagle.Fly();   // Output: Eagle is soaring high

        // Then
        var output = stringWriter.ToString().Trim();
        Assert.Contains("Eagle screeches", output);
        Assert.Contains("Eagle is soaring high", output);
    }

        [Fact]
    public void TestPenguin()
    {
        // Given
        Penguin penguin = new Penguin();

        // When
        penguin.Sound(); // Output: Penguin squawks
        penguin.Fly();   // Output: Penguin cannot fly
        penguin.Swim();  // Output: Penguin is swimming

        // Then
        var output = stringWriter.ToString().Trim();
        Assert.Contains("Penguin squawks", output);
        Assert.Contains("Penguin cannot fly", output);
        Assert.Contains("Penguin is swimming", output);
    }

    [Fact]
    public void TestFish()
    {
        // Given
        Fish fish = new Fish();

        // When
        fish.Sound(); // Output: Fish blubs

        // Then
        var output = stringWriter.ToString().Trim();
        Assert.Contains("Fish blubs", output);
    }

    [Fact]
    public void TestShark()
    {        // Given
        Shark shark = new Shark();

        // When
        shark.Sound(); // Output: Shark blubs
        shark.Swim();  // Output: Shark is swimming

        // Then
        var output = stringWriter.ToString().Trim();
        Assert.True(shark is ICanSwim);
        Assert.Contains("Shark growls", output);
        Assert.Contains("Shark is swimming", output);
    }

    [Fact]
    public void TestDolphin()
    {        // Given
        Dolphin dolphin = new Dolphin();

        // When
        dolphin.Sound(); // Output: Dolphin clicks
        dolphin.Swim();  // Output: Dolphin is swimming

        // Then
        var output = stringWriter.ToString().Trim();
        Assert.True(dolphin is Mammal);
        Assert.Contains("Dolphin clicks", output);
        Assert.Contains("Dolphin is swimming", output);
    }

    [Fact]
    public void TestShihTzu()
    {
        // Given
        ShihTzu shihTzu = new ShihTzu();

        // When
        shihTzu.Sound(); // Output: Shih Tzu barks
        shihTzu.Swim();  // Output: Shih Tzu is swimming
        shihTzu.Bark();  // Output: Shih Tzu barks

        // Then
        var output = stringWriter.ToString().Trim();
        Assert.Contains("Shih Tzu barks", output);
        Assert.Contains("Shih Tzu is swimming", output);
    }

    [Fact]
    public void TestInsect()
    {        // Given
        Insect insect = Insect.HatchBug();

        // When
        insect.Sound(); // Output: Insect buzzes

        // Then
        var output = stringWriter.ToString().Trim();
        Assert.Contains("Bug buzzes", output);
    }

    [Fact]
    public void TestBug()
    {        // Given
        var insect = Insect.HatchCaterpillar();
        var caterpillar = insect as Insect.ICaterpillar;

        // When
        insect.Sound(); // Output: Caterpillar is metamorphosing
        var it = caterpillar.Metamorphose();
        it.Sound(); // Output: Bug buzzes

        // Then
        var output = stringWriter.ToString().Trim();
        Assert.Contains("Caterpillar crawls", output);
        Assert.Contains("Caterpillar metamorphoses into a butterfly", output);
        Assert.Contains("Butterfly flutters", output);
    }
}
