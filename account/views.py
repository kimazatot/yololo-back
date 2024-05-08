import logging
from rest_framework.views import APIView
from rest_framework.response import Response
from .serializers import *
from rest_framework.authtoken.views import ObtainAuthToken
from rest_framework.permissions import IsAuthenticated
from rest_framework.authtoken.models import Token
from drf_yasg.utils import swagger_auto_schema

logger = logging.getLogger(__name__)


class RegistrationView(APIView):
    @swagger_auto_schema(request_body=RegistrationSerializer())
    def post(self, request):
        try:
            serializer = RegistrationSerializer(data=request.data)
            serializer.is_valid(raise_exception=True)
            serializer.save()
            return Response('Аккаунт успешно создан', status=201)
        except Exception as e:
            logger.error(f'Произошла ошибка: {e}')
            return Response('Произошла ошибка при регистрации', status=500)


class ActivationView(APIView):
    @swagger_auto_schema(request_body=ActivationSerializer())
    def post(self, request):
        try:
            serializer = ActivationSerializer(data=request.data)
            if serializer.is_valid(raise_exception=True):
                serializer.activate()
                return Response('Пользователь активирован', status=200)
        except Exception as e:
            logger.error(f'Произошла ошибка: {e}')
            return Response('Произошла ошибка при активации', status=500)


class LoginView(ObtainAuthToken):
    serializer_class = LoginSerializer


class LogoutView(APIView):
    permission_classes = [IsAuthenticated]

    def delete(self, request):
        user = request.user
        Token.objects.filter(user=user).delete()
        return Response('Вы успешно вышли')


class ChangePasswordView(APIView):
    permission_classes = [IsAuthenticated]

    @swagger_auto_schema(request_body=ChangePasswordSerializer())
    def post(self, request):
        try:
            serializer = ChangePasswordSerializer(data=request.data, context={'request': request})
            serializer.is_valid(raise_exception=True)
            serializer.set_new_password()
            return Response('Пароль успешно изменен', status=200)
        except Exception as e:
            logger.error(f'Произошла ошибка: {e}')
            return Response('Произошла ошибка при изменении пароля', status=500)


class ForgotPasswordView(APIView):
    @swagger_auto_schema(request_body=ForgotPasswordSerializer())
    def post(self, request):
        try:
            serializer = ForgotPasswordSerializer(data=request.data)
            serializer.is_valid(raise_exception=True)
            serializer.send_verification_email()
            return Response('Код для восстановления пароля отправлен на ваш email', status=200)
        except Exception as e:
            logger.error(f'Произошла ошибка: {e}')
            return Response('Произошла ошибка при восстановлении пароля', status=500)


class ForgotPasswordCompleteView(APIView):
    @swagger_auto_schema(request_body=ForgotPasswordCompleteSerializer())
    def post(self, request):
        try:
            serializer = ForgotPasswordCompleteSerializer(data=request.data)
            serializer.is_valid(raise_exception=True)
            serializer.set_new_password()
            return Response('Пароль успешно изменен', status=200)
        except Exception as e:
            logger.error(f'Произошла ошибка: {e}')
            return Response('Произошла ошибка при изменении пароля', status=500)
