using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

// Declare the first few notes of the song, "Mary Had A Little Lamb".
    Note[] Mary =
        {
        new Note(Tone.B, Figure.QUARTER, 120),
        new Note(Tone.A, Figure.QUARTER, 120),
        new Note(Tone.GbelowC, Figure.QUARTER, 120),
        new Note(Tone.A, Figure.QUARTER, 120),
        new Note(Tone.B, Figure.QUARTER, 120),
        new Note(Tone.B, Figure.QUARTER, 120),
        new Note(Tone.B, Figure.HALF, 120),
        new Note(Tone.A, Figure.QUARTER, 120),
        new Note(Tone.A, Figure.QUARTER, 120),
        new Note(Tone.A, Figure.HALF, 120),
        new Note(Tone.B, Figure.QUARTER, 120),
        new Note(Tone.D, Figure.QUARTER, 120),
        new Note(Tone.D, Figure.HALF, 120)
        };
// Play the song
    Play(Mary);


static double FrecuenciaNotas(int semitonos) => Math.Round(Math.Pow(2, semitonos/12.0), 4, MidpointRounding.ToPositiveInfinity) * 440.0;

// Play the notes in a song.
static void Play(Note[] tune)
{
    foreach (Note n in tune)
    {
        if (n.NoteTone == Tone.REST)
            Thread.Sleep(n.NoteDuration);
        else
            Console.Beep((int)n.NoteTone, n.NoteDuration);
    }
}

// Define the frequencies of notes in an octave, as well as silence (rest).
enum Tone
{
    REST   = 0,
    GbelowC = 196,
    A      = 220,
    Asharp = 233,
    B      = 247,
    C      = 262,
    Csharp = 277,
    D      = 294,
    Dsharp = 311,
    E      = 330,
    F      = 349,
    Fsharp = 370,
    G      = 392,
    Gsharp = 415,
}

// Define the value of a musical figure.
enum Figure
{
    WHOLE     = HALF*2,
    HALF      = QUARTER*2,
    QUARTER   = 1,
    EIGHTH    = QUARTER/2,
    SIXTEENTH = EIGHTH/2,
    THIRTY_SECOND = SIXTEENTH/2,
    SIXTY_FOURTH = THIRTY_SECOND/2,
}

struct Note
{
    Tone tone;
    Int32 duration;

// Define a constructor to create a specific note.
    public Note(Tone frequency, Figure time, Int32 tempo)
        {
        tone = frequency;
        duration  = 60_000/tempo*(Int32)time; // We take the tempo of the song and calculate the number of miliseconds per beat multiplied by the value of the musical figure
        }

// Define properties to return the note's tone and duration.
    public Tone NoteTone { get{ return tone; } }
    public Int32 NoteDuration { get{ return duration; } }
}





