using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectSource;
    private int isMusicOn;
    private int isSoundEffectsOn;
    private string isMusicOnPlayerPrefsName = "isMusicOn";
    private string isSoundEffectsOnPlayerPrefsName = "isSoundEffectsOn";


    [Header("--MUSIC--")]
    public AudioClip[] sfx_music_array;
    [Space]
    [Header("--SFX--HELI--")]
    public AudioClip sfx_helicopter_intro;
    public AudioSource heli_source;
    [Space]
    [Header("--SFX--WEAPONS--")]
    public AudioClip sfx_weapon_pistol;
    public AudioClip sfx_weapon_shotgun;
    public AudioClip sfx_weapon_shotgun2;
    public AudioClip sfx_weapon_assault1;
    public AudioClip sfx_weapon_smg1;
    public AudioClip sfx_weapon_smg3;
    public AudioClip sfx_weapon_rifle1;
    public AudioClip sfx_weapon_smg2;
    public AudioClip sfx_weapon_assault2;
    public AudioClip sfx_weapon_rifle2;
    public AudioClip sfx_weapon_assault3;
    public AudioClip sfx_weapon_rocketlauncher;
    public AudioClip sfx_weapon_machinegun1;
    public AudioClip sfx_weapon_machinegun2;
    [Space]
    [Header("--SFX--EXPLOSIONS")]
    public AudioClip[] sfx_explosion_barrels;
    [Space]
    [Header("--SFX--IMPACTS")]
    public AudioClip sfx_hitmarker;
    public AudioClip[] sfx_zombie_hits;
    public AudioClip sfx_impact_glass;
    [Space]
    [Header("--SFX--CASINGS")]
    public AudioClip[] sfx_casing_pistols;
    public AudioClip[] sfx_casing_shotguns;
    [Space]
    [Header("--SFX--UI--")]
    public AudioClip sfx_ui_buzz;
    public AudioClip sfx_ui_cash;
    public AudioClip sfx_ui_cash2;
    public AudioClip sfx_ui_equip;
    public AudioClip sfx_ui_punch;
    public AudioClip sfx_ui_shard;
    public AudioClip sfx_ui_tap;
    public AudioClip sfx_ui_tap2;




    private bool isPlayZombieHitAvailable = true;
    private bool isPlayingSong = true;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Init();
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Init()
    {
        if (GetIsMusicOn() == 1) // 1 means on.
        {
            PlayNewSong();
            ToggleMusicOn();
        } else
        {
            ToggleMusicOff();
            isPlayingSong = false;
        }
        if (GetIsSoundEffectsOn() == 1) // 1 means on.
        {
            //PlayHelicopterIntro();
            ToggleSoundEffectsOn();
        }else
        {
            ToggleSoundEffectsOff();
        }
    }

    //private void PlayHelicopterIntro()
    //{
    //    effectSource.PlayOneShot(sfx_helicopter_intro);
    //}

    public void PlayNewSong()
    {
        musicSource.Stop();
        musicSource.clip = sfx_music_array[Random.Range(0, sfx_music_array.Length)];
        musicSource.Play();
        musicSource.loop = true;
    }

    public void ToggleMusicOn()
    {
        musicSource.mute = false;
        if (!isPlayingSong)
        {
            PlayNewSong();
            isPlayingSong = true;
        }
    }

    public void ToggleMusicOff()
    {
        musicSource.mute = true;
    }

    public void ToggleSoundEffectsOn()
    {
        effectSource.mute = false;
        heli_source.mute = false;
    }

    public void ToggleSoundEffectsOff()
    {
        effectSource.mute = true;
        heli_source.mute = true;
    }

    //public void ChangeMasterVolume(float value)
    //{
    //    AudioListener.volume = value;
    //}

    //public void ToggleMusic()
    //{
    //    musicSource.mute = !musicSource.mute;
    //}

    //public void ToggleEffects()
    //{
    //    effectSource.mute = !effectSource.mute;
    //}

    private int GetIsMusicOn()
    {
        isMusicOn = PlayerPrefs.GetInt(isMusicOnPlayerPrefsName, 1);
        return isMusicOn;
    }

    private int GetIsSoundEffectsOn()
    {
        isSoundEffectsOn = PlayerPrefs.GetInt(isSoundEffectsOnPlayerPrefsName, 1);
        return isSoundEffectsOn;
    }




    //PLAY PUBLIC SFX**********
    public void Play_sfx_weapon_pistol()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_weapon_pistol);

            float _delay = Random.Range(0.75f, 2.25f);
            Invoke(nameof(Play_sfx_casing_pistol_Random), _delay);
        }
    }

    public void Play_sfx_weapon_shotgun()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_weapon_shotgun);

            float _delay = Random.Range(0.75f, 2.25f);
            Invoke(nameof(Play_sfx_casing_shotgun_Random), _delay);
        }
    }

    public void Play_sfx_weapon_shotgun2()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_weapon_shotgun2);

            float _delay = Random.Range(0.75f, 2.25f);
            Invoke(nameof(Play_sfx_casing_shotgun_Random), _delay);
        }
    }

    public void Play_sfx_weapon_assault1()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_weapon_assault1);

            float _delay = Random.Range(0.75f, 2.25f);
            Invoke(nameof(Play_sfx_casing_pistol_Random), _delay);
        }
    }

    public void Play_sfx_weapon_smg1()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_weapon_smg1);

            float _delay = Random.Range(0.75f, 2.25f);
            Invoke(nameof(Play_sfx_casing_pistol_Random), _delay);
        }
    }

    public void Play_sfx_weapon_smg3()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_weapon_smg3);

            float _delay = Random.Range(0.75f, 2.25f);
            Invoke(nameof(Play_sfx_casing_pistol_Random), _delay);
        }
    }

    public void Play_sfx_weapon_rifle1()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_weapon_rifle1);

            float _delay = Random.Range(0.75f, 2.25f);
            Invoke(nameof(Play_sfx_casing_pistol_Random), _delay);
        }
    }

    public void Play_sfx_weapon_smg2()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_weapon_smg2);

            float _delay = Random.Range(0.75f, 2.25f);
            Invoke(nameof(Play_sfx_casing_pistol_Random), _delay);
        }
    }

    public void Play_sfx_weapon_rifle2()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_weapon_rifle2);

            float _delay = Random.Range(0.75f, 2.25f);
            Invoke(nameof(Play_sfx_casing_pistol_Random), _delay);
        }
    }

    public void Play_sfx_weapon_assault2()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_weapon_assault2);

            float _delay = Random.Range(0.75f, 2.25f);
            Invoke(nameof(Play_sfx_casing_pistol_Random), _delay);
        }
    }


    public void Play_sfx_weapon_assault3()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_weapon_assault3);

            float _delay = Random.Range(0.75f, 2.25f);
            Invoke(nameof(Play_sfx_casing_pistol_Random), _delay);
        }
    }


    public void Play_sfx_weapon_rocketlauncher()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_weapon_rocketlauncher);

            float _delay = Random.Range(0.75f, 2.25f);
            Invoke(nameof(Play_sfx_casing_pistol_Random), _delay);
        }
    }





    public void Play_sfx_weapon_machinegun1()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_weapon_machinegun1);

            float _delay = Random.Range(0.75f, 2.25f);
            Invoke(nameof(Play_sfx_casing_pistol_Random), _delay);
        }
    }

    public void Play_sfx_weapon_machinegun2()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_weapon_machinegun1);

            float _delay = Random.Range(0.75f, 2.25f);
            Invoke(nameof(Play_sfx_casing_pistol_Random), _delay);
        }
    }







    public void Play_sfx_explosion_barrel_Random()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            Play_sfx_hitmarker();

            effectSource.PlayOneShot(sfx_explosion_barrels[Random.Range(0, sfx_explosion_barrels.Length)]);
        }
    }

    public void Play_sfx_hitmarker()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_hitmarker);
        }
    }


    public void Play_sfx_zombie_hit_Random()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            if (isPlayZombieHitAvailable)
            {
                Play_sfx_hitmarker();

                effectSource.PlayOneShot(sfx_zombie_hits[Random.Range(0, sfx_zombie_hits.Length)]);

                isPlayZombieHitAvailable = false;

                Invoke(nameof(ZombieHitAvailable), 0.01f);
            }
        }
    }

    
    public void Play_sfx_impact_glass()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_impact_glass);
        }
    }




    void Play_sfx_casing_pistol_Random()
    {
        effectSource.PlayOneShot(sfx_casing_pistols[Random.Range(0, sfx_casing_pistols.Length)]);
    }

    void Play_sfx_casing_shotgun_Random()
    {
        effectSource.PlayOneShot(sfx_casing_shotguns[Random.Range(0, sfx_casing_shotguns.Length)]);
    }


    void ZombieHitAvailable()
    {
        isPlayZombieHitAvailable = true;
    }
    //PLAY PUBLIC SFX**********



    public void Play_sfx_ui_buzz()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_ui_buzz);
        }
    }
    
    public void Play_sfx_ui_cash()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_ui_cash);
        }
    }
    
    public void Play_sfx_ui_cash2()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_ui_cash2);
        }
    }
    
    public void Play_sfx_ui_equip()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_ui_equip);
        }
    }
    
    public void Play_sfx_ui_punch()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_ui_punch);
        }
    }
    
    public void Play_sfx_ui_shard()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_ui_shard);
        }
    }
    
    public void Play_sfx_ui_tap()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_ui_tap);
        }
    }
    
    public void Play_sfx_ui_tap2()
    {
        if (GetIsSoundEffectsOn() == 1)
        {
            effectSource.PlayOneShot(sfx_ui_tap2);
        }
    }



}
