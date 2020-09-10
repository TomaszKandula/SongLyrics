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
        transition: {
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
        transition: {
            type: "tween",
            duration: 500
        }
    }
};

export const scaledFadeAnimation =
{
    enter:
    {
        scale: 1,
        opacity: 1
    },
    exit:
    {
        scale: 1.2,
        opacity: 0
    }
};

export const MainContainer = posed.div(fadeInAnimation);
export const ScaleTitle    = posed.h1(scaledFadeAnimation);
export const ScalePara     = posed.p(scaledFadeAnimation);
export const ScaleLink     = posed.a(scaledFadeAnimation);
export const ScaleDiv      = posed.div(scaledFadeAnimation);
export const FadeInDiv     = posed.div(fadeInAnimation);
export const FadeOutDiv    = posed.div(fadeOutAnimation);
