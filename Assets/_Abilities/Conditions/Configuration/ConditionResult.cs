using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Abilities {
    public class ConditionResult {

        private bool isSuccessful;
        private string resultMessage;

        public ConditionResult() {
        }
        public ConditionResult(bool isSuccessful) {
            this.isSuccessful = isSuccessful;
        }
        public ConditionResult(bool isSuccessful, string resultMessage) {
            this.isSuccessful = isSuccessful;
            this.resultMessage = resultMessage;
        }
        public bool IsSuccessful {
            get {
                return isSuccessful;
            }
            set {
                this.isSuccessful = value;
            }
        }
        public string ResultMessage {
            get {
                return resultMessage;
            }
            set {
                this.resultMessage = value;
            }
        }
    }
}