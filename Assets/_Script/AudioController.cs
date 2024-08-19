using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    [Range(0,1)]
    public float musicVolume;
    [Range(0, 1)]
    public float soundVolume;

    public AudioSource musicAus;
    public AudioSource soundAus;

    public AudioClip[] backgroundMusic;
    public AudioClip rightSound;
    public AudioClip loseSound;
    public AudioClip wintSound;

    protected void Awake()
    {
        this.MakeSingleTon();
    }
    void Start()
    {
        this.PlayBackgroundMusic(); 
    }

    protected void Update()
    {
        if(this.musicAus && this.soundAus)
        {
            this.musicAus.volume = this.musicVolume;
            this.soundAus.volume = this.soundVolume;
        }    
    }
    public void PlayBackgroundMusic()
    {
        if(this.musicAus && this.backgroundMusic != null && this.backgroundMusic.Length > 0)
        {
            int randIdx = Random.Range(0, this.backgroundMusic.Length);
            if (backgroundMusic[randIdx] != null)
            {
                this.musicAus.clip = this.backgroundMusic[randIdx];
                this.musicAus.volume = this.musicVolume;
                this.musicAus.Play();
            }
        }
    }    
    public void PlaySound(AudioClip sound)
    {
        if(this.soundAus && sound)
        {
            this.soundAus.PlayOneShot(sound);
            this.soundAus.volume = this.soundVolume;
        }
    }    
   
    public void PlayRightSound()
    {
        PlaySound(rightSound);
    }    

    public void PlayLoseSound()
    {
        PlaySound(loseSound);
    } 
    public void PlayWinSound()
    {
        PlaySound(wintSound);
    }    
    public void StopMusic()
    {
        if (this.musicAus) this.musicAus.Stop();
    }    
    public void MakeSingleTon()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
}
