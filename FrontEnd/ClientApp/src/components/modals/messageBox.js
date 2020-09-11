import React, { Component } from "react";
import { connect } from "react-redux";
import * as ActionTypes from "../../redux/actionTypes";
import * as MessageTypes from "../common/messageTypes";
import * as Posed from "../common/posedComponents";

class MessageBox extends Component
{

    closeModal()
    {
        this.props.dispatch(
        {
            type: ActionTypes.SHOW_MESSAGE,
            payload:
            {
                messageType: this.props.messageData.messageType,
                lastText: this.props.messageData.lastText,
                isVisible: false
            }
        });
    }

    modalContent()
    {

        let messageHeader = "";
        switch (this.props.messageData.messageType)
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

            <div className="message-modal">

                <div className="message-modal-content">
                    <h4>{messageHeader}</h4>
                    <p>{this.props.messageData.lastText}</p>
                    <div className="message-modal-footer">
                        <div className="waves-effect waves-light btn" onClick={this.closeModal.bind(this)}>OK</div>
                    </div>
                </div>

            </div>
            
        );

    }

    renderIn()
    {

        document.body.classList.add("messageBox-open");

        return (
            <Posed.FadeInDiv initialPose="hidden" pose="visible">
                {this.modalContent()}
            </Posed.FadeInDiv>           
        );

    }

    renderOut()
    {

        let isModalOpened = document.body.classList.contains("messageBox-open");

        if (isModalOpened)
        {

            document.body.classList.remove("messageBox-open");

            return (
                <Posed.FadeOutDiv initialPose="visible" pose="hidden">
                    {this.modalContent()}
                </Posed.FadeOutDiv>
            );

        }
        else
        {
            return null;
        }

    }

    render()
    {

        let rendered = this.props.messageData.isVisible ? this.renderIn() : this.renderOut();

        return (

            <div>
                {rendered}
            </div>

        );

    }

}

const mapStateToProps = (state) =>
{
    return { messageData: state.message }
}

export default connect(mapStateToProps)(MessageBox)
