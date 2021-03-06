﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SongLyrics.Infrastructure.Domain.Entities;

namespace SongLyrics.Infrastructure.Database.Seeders
{
    public class SongsSeeder : IMainDbContextSeeder
    {
        public void Seed(ModelBuilder AModelBuilder)
            => AModelBuilder.Entity<Songs>().HasData(CreateSongList());

        private static IEnumerable<Songs> CreateSongList()
        {
            return new List<Songs>
            {
                new Songs
                {
                    Id = 1,
                    AlbumId = 1,
                    ArtistId = 1,
                    SongName = "Keep Yourself Alive",
                    SongUrl = "https://www.youtube.com/embed/MfILg4mJAG0",
                    SongLyrics = "Take off<br>I was told a million times<br>Of all the troubles in my way<br>Mind you grow a little wiser<br>Little better every day<br>But if I crossed a million rivers<br>And I rode a million miles<br>Then I'd still be where I started<br>Bread and butter for a smile<br>Well I sold a million mirrors<br>In a shopping alley way<br>But I never saw my face<br>In any window any day<br>Now they say your folks are telling you<br>Be a super star<br>But I tell you just be satisfied<br>Stay right where you are<br>Keep yourself alive; yeah<br>Keep yourself alive<br>Ooh; it'll take you all your time and money<br>Honey you'll survive<br>Ow<br>Well I've loved a million women<br>In a belladonic haze<br>And I ate a million dinners<br>Brought to me on silver trays<br>Give me everything I need<br>To feed my body and my soul<br>And I'll grow a little bigger<br>Maybe that can be my goal<br>I was told a million times<br>Of all the people in my way<br>How I had to keep on trying<br>And get better every day<br>But if I crossed a million rivers<br>And I rode a million miles<br>Then I'd still be where I started<br>Same as when I started<br>Keep yourself alive; come on<br>Keep yourself alive<br>Ooh; it'll take you all your time and money honey<br>You'll survive; shake<br>Ow<br>Keep yourself alive; wow<br>Keep yourself alive<br>Oh; it'll take you all your time and money<br>To keep me satisfied<br>Do you think you're better every day?<br>No; I just think I'm two steps nearer to my grave<br>Keep yourself alive; c'mon<br>Keep yourself alive<br>Mm; you take your time and take more money<br>Keep yourself alive<br>Keep yourself alive<br>C'mon keep yourself alive<br>All you people keep yourself alive<br>Keep yourself alive<br>C'mon c'mon keep yourself alive<br>It'll take you all your time and a money<br>To keep me satisfied<br>Keep yourself alive<br>Keep yourself alive<br>All you people keep yourself alive<br>Take you all your time and money honey<br>You will survive<br>Keep you satisfied"
                },
                new Songs 
                {
                    Id = 2,
                    AlbumId = 1,
                    ArtistId = 1,
                    SongName = "Doing All Right",
                    SongUrl = "https://www.youtube.com/embed/AqP8xLF3TE4",
                    SongLyrics = "Yesterday my life was in ruin<br>Now today I know what I'm doing<br>Gotta feeling I should be doing all right<br>Doing all right<br>Where will I be this time tomorrow<br>Jump in joy or sinking in sorrow<br>Anyway I should be doing all right<br>Doing all right<br>Should be waiting for the sun<br>Looking round to find the words to say<br>Should be waiting for the skies to clear<br>There a time in all the world<br>Should be waiting for the sun<br>And anyway I've got hide away<br>Ah ah ah ah<br>Yesterday my life was in ruin<br>Now today God knows what I'm doing<br>Anyway I should be doing all right<br>Doing all right<br>Doing all right"
                },
                new Songs
                {
                    Id = 3,
                    AlbumId = 1,
                    ArtistId = 1,
                    SongName = "Great King Rat",
                    SongUrl = "https://www.youtube.com/embed/VHC85XWII7E",
                    SongLyrics = "Great King Rat died today<br>Born on the twenty first of May<br>Died syphilis forty four on his birthday<br>Every second word he swore<br>Yes he was the son of a whore<br>Always wanted by the law<br>Wouldn't you like to know?<br>Wouldn't you like to know people?<br>Great King Rat was a dirty old man<br>And a dirty old man was he<br>Now what did I tell you<br>Would you like to see?<br>Now hear this<br>Where will I be tomorrow?<br>Will I beg ?; Will I borrow?<br>I don't care; I don't care anyway<br>Come on; come on the time is right<br>The man is evil and that is right<br>I told you ah yes I told you<br>And that's no lie; oh no no<br>Wouldn't you like to know?<br>Wouldn't you like to know?<br>Wouldn't you like to know?<br>Great King Rat was a dirty old man<br>And a dirty old man was he<br>Now what did I tell you<br>Would you like to see?<br>Show me<br>Oooh oooh oooh oooh<br>Wouldn't you like to know?<br>Wouldn't you like to know people people?<br>Great King Rat was a dirty old man<br>And a dirty old man was he<br>Now what did I tell you<br>Would you like to see?<br>Hit it<br>Now listen all you people<br>Put out the good and keep the bad<br>Don't believe all you read in the Bible<br>You sinners get in line<br>Saints you leave far behind<br>Very soon you're gonna be his disciple<br>Don't listen to what mama says<br>Not a word not a word mama says<br>Or else you'll find yourself being the rival<br>Sure; the great lord before he died<br>Knelt sinners by his side<br>And said you're going to realise tomorrow; oh woh oh woh oh woh<br>No I'm not going to tell you<br>What you already know<br>'Cause time and time again<br>The old man said it all a long time ago<br>Come on come on the time is right<br>This evil man will fight<br>I told you once before<br>Hear it<br>No<br>Wouldn't you like to know?<br>Wouldn't you like to know?<br>Just like I said before<br>Great King Rat was a dirty old man<br>And a dirty old man was he<br>The last time I tell you<br>Would you like to see?"
                },
                new Songs
                {
                    Id = 4,
                    AlbumId = 1,
                    ArtistId = 1,
                    SongName = "My Fairy King",
                    SongUrl = "https://www.youtube.com/embed/VeVjEg4znQk",
                    SongLyrics = "Aah; aah<br>In the land where horses born with eagle wings<br>And honey bees have lost their stings<br>There's singing forever; ooh yeah<br>Lion's den with fallow deer<br>And rivers made from wine so clear<br>Flow on and on forever<br>Dragons fly like sparrows thru' the air<br>And baby lambs where Samson dares<br>To go on on on on on on<br>My fairy king can see things<br>He rules the air and turns the tides<br>That are not there for you and me<br>Ooh yeah he guides the winds<br>My fairy king can do right and nothing wrong<br>Ah; then came man to savage in the night<br>To run like thieves and to kill like knives<br>To take away the power from the magic hand<br>To bring about the ruin to the promised land; aah; aah<br>They turn the milk into sour<br>Like the blue in the blood of my veins<br>Why can't you see it<br>Fire burning in hell with the cry of screaming pain<br>Son of heaven set me free and let me go<br>Sea turn dry; no salt from sand<br>Seasons fly no helping hand<br>Teeth don't shine like pearls for poor man's eyes; aah<br>Someone; someone has drained the colour from my wings<br>Broken my fairy circle ring<br>And shamed the king in all his pride<br>Changed the winds and wronged the tides<br>Mother Mercury Mercury<br>Look what they've done to me<br>I cannot run; I cannot hide<br>La la la la la la la la la la la la"
                },
                new Songs
                {
                    Id = 5,
                    AlbumId = 1,
                    ArtistId = 1,
                    SongName = "Liar",
                    SongUrl = "https://www.youtube.com/embed/oU7rqB9E_0M",
                    SongLyrics = "I don't care if you're here<br>Or if you're not alone<br>I don't care; it's been too long<br>It's kinda like we didn't happen<br>The way that your lips move<br>The way you whisper slow<br>I don't care; it's good as gone (uh)<br>I said I won't lose control; I don't want it (ooh)<br>I said I won't get too close; but I can't stop it<br>Oh no; there you go; making me a liar<br>Got me begging you for more<br>Oh no; there I go; startin' up a fire<br>Oh no; no (oh no)<br>Oh no; there you go; you're making me a liar<br>I kinda like it though<br>Oh no; there I go; startin' up a fire<br>Oh no; no (ooh)<br>You're watching; I feel it (hey)<br>I know I shouldn't stare (yeah; yeah)<br>I picture your hands on me (I think I wanna let it happen)<br>But what if; you kiss me? (Yeah)<br>And what if; I like it?<br>And no one sees it<br>I said I won't lose control; I don't want it (ooh)<br>I said I won't get too close; but I can't stop it (no)<br>Oh no; there you go; making me a liar<br>Got me begging you for more<br>Oh no; there I go; startin' up a fire<br>Oh no; no (oh no)<br>Oh no; there you go; you're making me a liar<br>I kinda like it though<br>Oh no; there I go; startin' up a fire<br>Oh no; no<br>Oh no; no; no<br>Here comes trouble; no; no<br>Startin' up a fire<br>I don't believe myself when I<br>Say that I don't need you; oh<br>I don't believe myself when I say it<br>So; don't believe me<br>Oh no; there you go; you're making me a liar<br>Got me begging you for more<br>Oh no; there I go; startin' up a fire<br>Oh no; no (oh no)<br>Oh no; there you go; you're making me a liar<br>I kinda like it though<br>Oh no; there I go; startin' up a fire<br>Oh no; no<br>Yeah; uh; yeah<br>Uh; yeah<br>Oh no; no; no; oh no; no; no<br>Oh no; you're making me a liar<br>'Cause my clothes are on the floor<br>Huh; huh; huh; uh<br>Oh no; no; no<br>Another fire"
                },
                new Songs
                {
                    Id = 6,
                    AlbumId = 1,
                    ArtistId = 1,
                    SongName = "The Night Comes Down",
                    SongUrl = "https://www.youtube.com/embed/dCPQS_sKJXQ",
                    SongLyrics = "When I was young it came to me<br>And I could see the sun breakin'<br>Lucy was high and so was I dazzling<br>Holding the world inside<br>Once I believed in ev'ryone<br>Everyone and anyone can see<br>Oh oh the night comes down<br>And I get afraid of losing my way<br>Oh oh the night comes down<br>Oooh and it's dark again<br>Once I could laugh with ev'ryone<br>Once I could see the good in me<br>The black and the white distinctively coloring<br>Holding the world inside<br>Now all the world is grey to me<br>Nobody can see you gotta believe it<br>Oh oh the night comes down<br>And I get afraid of losing my way<br>Oh oh the night comes down<br>Oooh and it's dark again<br>And it's dark again<br>And it's dark again"
                },
                new Songs
                {
                    Id = 7,
                    AlbumId = 1,
                    ArtistId = 1,
                    SongName = "Modern Times Rock 'n' Roll",
                    SongUrl = "https://www.youtube.com/embed/jZa9nAmqGeA",
                    SongLyrics = "Had to make do with a worn out rock and roll scene<br>The old bop is gettin' tired need a rest<br>Well you know what I mean<br>Fifty eight that was great<br>But it's over now and That's all<br>Somethin' harder's coming up<br>Gonna really knock a hole in the wall<br>Gonna hit ya grab you hard<br>Make you feel ten feet tall<br>Well I hope this baby's gonna come along soon<br>You don't know it could happen any ol' rainy afternoon<br>With the temperature down<br>And the jukebox blowin' no fuse<br>And my musical life's feelin'<br>Like a long Sunday School cruise<br>And you know there's one thing<br>Every single body could use<br>Yeah listen to me baby<br>Let me tell you what it's all about<br>Modern times rock and roll<br>Modern times rock and roll<br>Get you high heeled guitar boots and some groovy clothes<br>Get a hair piece on your chest<br>And a ring through your nose<br>Find a nice little man who says<br>He's gonna make you a real big star<br>Stars in your eyes and ants in your pants<br>Think you should go far<br>Everybody in this bum sucking world<br>Gonna know just who you are<br>Look out<br>Modern times rock and roll"
                },
                new Songs
                {
                    Id = 8,
                    AlbumId = 1,
                    ArtistId = 1,
                    SongName = "Son and Daughter",
                    SongUrl = "https://www.youtube.com/embed/StXGu0KXpA8",
                    SongLyrics = "I want you... woman<br><br>Tried to be a son and daughter rolled into one<br>You said you'd equal any man for having your fun<br>Now didn't you feel surprised to find<br>The cap just didn't fit?<br><br>The world expects a man<br>To buckle down and to shovel shit<br>What'll you do for loving<br>When it's only just begun?<br>I want you to be a woman<br><br>Tried to be a teacher and a fisher of men<br>An equal people preacher<br>Will you lead us all the same?<br>Well I traveled all around the world<br><br>A brand new word for day<br>Watching the time mustn't linger behind<br>Pardon me I have to get away<br>What'll you think of heaven<br><br>If it's back from where you came?<br>I want you to be a woman"
                },
                new Songs
                {
                    Id = 9,
                    AlbumId = 1,
                    ArtistId = 1,
                    SongName = "Jesus",
                    SongUrl = "https://www.youtube.com/embed/z0J_kuTib1w",
                    SongLyrics = "And then I saw Him in the crowd<br>A lot of people had gathered round Him<br>The beggars shouted the lepers called Him<br>The old man said nothing<br>He just stared about him<br>All going down to see the Lord Jesus<br>All going down to see the Lord Jesus<br>All going down<br>Then came a man before His feet he fell<br>Unclean said the leper and rang his bell<br>Felt the palm of a hand touch his head<br>Go now go now you're a new man instead<br>All going down to see the Lord Jesus<br>All going down to see the Lord Jesus<br>All going down<br>It all began with the three wise men<br>Followed a star took them to Bethlehem<br>And made it heard throughout the land<br>Born was a leader of man<br>All going down to see the Lord Jesus<br>All going down to see the Lord Jesus<br>All going down<br>It all began with the three wise men<br>Followed a star took them to Bethlehem<br>And made it heard throughout the land<br>Born was a leader of man<br>All going down to see the Lord Jesus<br>All going down to see the Lord Jesus<br>All going down"
                },
                new Songs
                {
                    Id = 10,
                    AlbumId = 1,
                    ArtistId = 1,
                    SongName = "Seven Seas of Rhye",
                    SongUrl = "https://www.youtube.com/embed/FxIo57WURRE",
                    SongLyrics = "Fear me you lords and lady preachers<br>I descend upon your earth from the skies<br>I command your very souls you unbelievers<br>Bring before me what is mine<br>The seven seas of rhye<br>Can you hear me you peers and privvy counsellors<br>I stand before you naked to the eyes<br>I will destroy any man who dares abuse my trust<br>I swear that you'll be mine<br>The seven seas of rhye<br>Sister I live and lie for you<br>Mister do and I'll die<br>You are mine I possess you<br>I belong to you forever<br>Storm the master marathon I'll fly through<br>By flash and thunder fire I'll survive<br>Then I'll defy the laws of nature and come out alive<br>Then I'll get you<br>Be gone with you; you shod and shady senators<br>Give out the good; leave out the bad evil cries<br>I challenge the mighty titan and his troubadours<br>And with a smile<br>I'll take you to the seven seas of rhye"
                }
            };
        }
    }
}
