import React, { Component } from "react";
import { connect } from "react-redux";

class MessageBox extends Component
{

    constructor(props)
    {
        super(props);

    }

    render()
    {

        return (

            <div className="invisible">



            </div>

        );

    }

}

export default connect()(MessageBox)
