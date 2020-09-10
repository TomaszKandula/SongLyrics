import posed from "react-pose";

// common opacity animation
export const fadeAnimation =
{
    exit: { opacity: 0 },
    enter: {
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

// common scale + opacity animation
export const scaledFadeAnimation =
{
    enter: {
        scale: 1,
        opacity: 1
    },
    exit: {
        scale: 1.2,
        opacity: 0
    }
};

export const Container = posed.div(fadeAnimation);
export const Title = posed.h1(scaledFadeAnimation);
export const Div = posed.div(scaledFadeAnimation);
export const Paragraph = posed.p(scaledFadeAnimation);
export const Link = posed.a(scaledFadeAnimation);
export const FadeDiv = posed.div(fadeAnimation);
