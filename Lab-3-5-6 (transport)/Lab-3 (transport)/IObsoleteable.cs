
namespace Transport {
    interface IObsoleteable {
        bool Relevant { get; }
        void MakeOlder(uint seconds);
    }
}
