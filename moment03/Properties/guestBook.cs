using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

class Prop
{
    public int Id;
    public string? guestName;
    public string? posts;

    public Prop(string aGuestName, string aGuestPost, int aId) {
        Id = aId;
        guestName = aGuestName;
        posts = aGuestPost;
    }

}

