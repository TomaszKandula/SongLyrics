import React, { Component } from "react";
import { connect } from "react-redux";
import * as ActionTypes from "../../redux/actionTypes";
import * as MessageTypes from "../common/messageTypes";
import * as Posed from "../common/posedComponents";

class MessageBox extends Component
{

    closeModal()
    {
        this.props.dispatch({ type: ActionTypes.SHOW_MESSAGE, payload: { messageType: "", lastText: "" } });
    }

    renderMessageBox()
    {

        let messageHeader = "";
        switch (this.props.message.messageType)
        {

            case MessageTypes.MESSAGE_INFO:
                messageHeader = "Information";
                break;

            case MessageTypes.MESSAGE_WARN:
                messageHeader = "Warning";
                break;

            case MessageTypes.MESSAGE_ERROR:
                messageHeader = "Error";
                break;

            default:
                messageHeader = "Information";

        }

        return (

            <Posed.PosedFadeDiv initialPose="exit" pose="enter">

                <div className="custom-modal">

                    <div className="custom-modal-content">
                        <h4>{messageHeader}</h4>
                        <p>{this.props.message.lastText}</p>
                        <div className="custom-modal-footer">
                            <div className="waves-effect waves-light btn" onClick={this.closeModal.bind(this)}>OK</div>
                        </div>
                    </div>

                </div>

            </Posed.PosedFadeDiv>
            
        );

    }

    render()
    {

        let rendered = this.props.isShown ? this.renderMessageBox() : null;

        return (

            <div>
                {rendered}
            </div>

        );

    }

}

const mapStateToProps = (state) =>
{
    let isVisible = true;
    if (state.message.lastText === "") { isVisible = false; }
    return { isShown: isVisible, message: state.message }
}

export default connect(mapStateToProps)(MessageBox)
