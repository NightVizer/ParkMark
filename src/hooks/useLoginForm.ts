import { useState } from 'react'
import type { FormEvent } from 'react'

type LoginField = 'userId' | 'password'

export function useLoginForm() {
  const [values, setValues] = useState({ userId: '', password: '' })
  const [touched, setTouched] = useState({ userId: false, password: false })
  const [submitted, setSubmitted] = useState(false)

  const errors = {
    userId: values.userId.trim() ? '' : 'Введите ID',
    password: values.password.length ? '' : 'Введите пароль',
  }
  const canSubmit = !errors.userId && !errors.password

  function changeField(field: LoginField, value: string) {
    setValues((previous) => ({ ...previous, [field]: value }))
    setSubmitted(false)
  }

  function blurField(field: LoginField) {
    setTouched((previous) => ({ ...previous, [field]: true }))
  }

  function handleSubmit(event: FormEvent<HTMLFormElement>) {
    event.preventDefault()
    setTouched({ userId: true, password: true })
    setSubmitted(canSubmit)
  }

  return { values, touched, errors, canSubmit, submitted, changeField, blurField, handleSubmit }
}
