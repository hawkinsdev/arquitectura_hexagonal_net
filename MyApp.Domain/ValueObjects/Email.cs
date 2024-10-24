namespace MyApp.Domain.ValueObjects {

    public class Email {
        public string Value { get; }
        public Email(string value) {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                throw new ArgumentException("Invalid email address");
            Value = value;
        }

        public override string ToString() => Value;
        public override bool Equals(object obj) => obj is Email email && Value == email.Value;
        public override int GetHashCode() => Value.GetHashCode();
    }
}