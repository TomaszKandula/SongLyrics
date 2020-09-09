import React, { Component } from "react";
import { connect } from "react-redux";

class MessageBox extends Component
{

    renderMessageBox()
    {

        let messageHeader = "";
        switch (this.props.message.messageType)
        {

            case "MESSAGE_INFO":
                messageHeader = "Information";
                break;

            case "MESSAGE_WARN":
                messageHeader = "Warning";
                break;

            case "MESSAGE_ERROR":
                messageHeader = "Error";
                break;

            default:
                messageHeader = "Information";

        }

        return (

            <div>

                <div class="modal">
                    <div class="modal-content">
                        <h4>{messageHeader}</h4>
                        <p>{ this.props.message.lastText }</p>
                    </div>
                    <div class="modal-footer">
                        <div class="modal-close waves-effect waves-green btn-flat">OK</div>
                    </div>
                </div>

            </div>
            
        );

    }

    render()
    {

        return (

            <div>
                { this.props.isShown ? this.renderMessageBox : null }
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
