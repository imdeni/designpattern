using System;

// State interface
interface PackageState {
    void UpdateState(DeliveryContext context);
}

// Concrete state classes
class OrderedState : PackageState {
    public void UpdateState(DeliveryContext context) {
        Console.WriteLine("Package is in the ordered state.");
        context.SetState(new ShippedState());
    }
}

class ShippedState : PackageState {
    public void UpdateState(DeliveryContext context) {
        Console.WriteLine("Package is in the shipped state.");
        context.SetState(new DeliveredState());
    }
}

class DeliveredState : PackageState {
    public void UpdateState(DeliveryContext context) {
        Console.WriteLine("Package is in the delivered state.");
        // Additional logic or actions specific to the delivered state
    }
}

// Context class
class DeliveryContext {
    private PackageState currentState;

    public DeliveryContext() {
        currentState = new OrderedState();
    }

    public void SetState(PackageState state) {
        currentState = state;
    }

    public void Update() {
        currentState.UpdateState(this);
    }
}

// Usage example
public class Program {
    public static void Main(string[] args) {
        DeliveryContext context = new DeliveryContext();
        context.Update(); // Transition to ShippedState
        context.Update(); // Transition to DeliveredState
    }
}