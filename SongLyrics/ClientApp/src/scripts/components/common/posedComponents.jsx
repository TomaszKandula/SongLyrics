import posed from "react-pose";

export const fadeInAnimation =
{
    hidden:
    {
        applyAtStart: { display: 'block' },
        opacity: 0
    },
    visible:
    {
        opacity: 1,
        delay: 100,
        beforeChildren: true,
        delayChildren: 200,
        staggerChildren: 50,
        transition:
        {
            type: "tween",
            duration: 500
        }
    }
};

export const fadeOutAnimation =
{
    visible:
    {
        opacity: 1
    },
    hidden:
    {
        applyAtEnd: { display: "none" },
        opacity: 0,
        delay: 100,
        beforeChildren: true,
        delayChildren: 200,
        staggerChildren: 50,
        transition:
        {
            type: "tween",
            duration: 500
        }
    }
};

export const scaledAnimation =
{
    hidden:
    {
        scale: 0,
        opacity: 1
    },
    visible:
    {
        scale: 1,
        opacity: 1
    }
};

export const MainContainer = posed.div(fadeInAnimation);
export const ScaleTitle    = posed.h1(scaledAnimation);
export const ScalePara     = posed.p(scaledAnimation);
export const ScaleLink     = posed.a(scaledAnimation);
export const ScaleDiv      = posed.div(scaledAnimation);
export const FadeInDiv     = posed.div(fadeInAnimation);
export const FadeOutDiv    = posed.div(fadeOutAnimation);
