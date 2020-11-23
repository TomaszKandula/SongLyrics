import React, { Component } from "react";

class Circular extends Component
{

    render()
    {

        return (
            <div>

                <div className="row">

                    <div className="col s5"></div>

                    <div className="col s2">

                        <div className="preloader-wrapper small active">
                            <div className="spinner-layer spinner-green-only">
                                <div className="circle-clipper left">
                                    <div className="circle"></div>
                                </div>
                                <div className="gap-patch">
                                    <div className="circle"></div>
                                </div>
                                <div className="circle-clipper right">
                                    <div className="circle"></div>
                                </div>
                            </div>
                        </div>

                    </div>

                    <div className="col s5"></div>

                </div>

            </div>
        );

    }
}

class Linear extends Component
{

    render()
    {

        return (
            <div>

                <div className="row">

                    <div className="col s2"></div>

                    <div className="col s8">
                        <div className="progress">
                            <div className="indeterminate"></div>
                        </div>            
                    </div>

                    <div className="col s2"></div>

                </div>

            </div>
        );

    }

}

export
{
    Circular,
    Linear
}
